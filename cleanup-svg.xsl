<?xml version="1.0" encoding="utf-8"?>
<!-- 
	from: https://gist.github.com/maxkoryukov/b83af25b8d3739a698909ae648c26f93#file-cleanup-svg-xsl 
	How to run it:
	 1. Install tool: dotnet core tool BinaryDataDecoders.Xslt.Cli
	 2 Get-ChildItem .\ *.svg|%{ bdd-xslt -i $_.Fullname -t cleanup-svg.xsl -o (join-path D:\temp\xdt-test\output $_.Name)}
-->
<xsl:stylesheet
	version="1.0"
	xmlns:dc="http://purl.org/dc/elements/1.1/"
	xmlns:cc="http://creativecommons.org/ns#"
	xmlns:rdf="http://www.w3.org/1999/02/22-rdf-syntax-ns#"
	xmlns:svg="http://www.w3.org/2000/svg"
	xmlns="http://www.w3.org/2000/svg"
	xmlns:sodipodi="http://sodipodi.sourceforge.net/DTD/sodipodi-0.dtd"
	xmlns:inkscape="http://www.inkscape.org/namespaces/inkscape"

	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	exclude-result-prefixes="xsl inkscape sodipodi rdf">

	<xsl:output method="xml" encoding="utf-8" indent="no" standalone="no"/>

	<xsl:variable name="inkscape-ns" select="'http://www.inkscape.org/namespaces/inkscape'" />
	<xsl:variable name="sodipodi-ns" select="'http://sodipodi.sourceforge.net/DTD/sodipodi-0.dtd'" />
	<xsl:variable name="preserve-style" select="false()" /><!-- TODO: use as="xs:boolean", XSLT-2 -->

	<xsl:template match="@*">
		<xsl:choose>
			<xsl:when test="namespace-uri(.)=$inkscape-ns">
			</xsl:when>

			<xsl:when test="namespace-uri(.)=$sodipodi-ns">
			</xsl:when>

			<xsl:when test="local-name()='style'">
				<xsl:if test="$preserve-style">
					<xsl:copy />
				</xsl:if>
			</xsl:when>

			<xsl:otherwise>
				<xsl:copy />
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>

	<xsl:template match="node()">
		<xsl:choose>
			<xsl:when test="name()='metadata'">
			</xsl:when>

			<xsl:when test="namespace-uri(.)=$inkscape-ns">
			</xsl:when>
			<xsl:when test="namespace-uri(.)=$sodipodi-ns">
			</xsl:when>

			<xsl:otherwise>
				<xsl:copy>
					<xsl:apply-templates select="* | @*"/>
				</xsl:copy>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>


</xsl:stylesheet>